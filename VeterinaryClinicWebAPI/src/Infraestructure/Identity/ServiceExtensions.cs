﻿using System;
using System.Text;
using Identity.Context;
using Identity.Models;
using Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using VeterinaryClinic.Core.Application.Interfaces;
using VeterinaryClinic.Core.Application.Wrappers;
using VeterinaryClinic.Core.Domain.Settings;

namespace Identity
{
	public static class ServiceExtensions
	{
		public static void AddIdentityInfraestructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<IdentityContext>(options => options.UseSqlServer(
				configuration.GetConnectionString("IdentityConnection")!,
				b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)
				));

			services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
			#region Services
			services.AddTransient<IAccountservice, AccountService>();
			#endregion
			services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(o =>
			{
				o.RequireHttpsMetadata = false;
				o.SaveToken = false;
				o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero,
					ValidIssuer =  configuration["JWTSettings:Issuer"],
					ValidAudience =  configuration["JWTSettings:Audience"],
					IssuerSigningKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:key"]!))
				};

				o.Events = new JwtBearerEvents()
				{
					OnAuthenticationFailed = c =>
					{
						c.NoResult();
						c.Response.StatusCode = 500;
						c.Response.ContentType = "text/plain";
						return c.Response.WriteAsync(c.Exception.ToString());
					},
					OnChallenge = context =>
					{
						context.HandleResponse();
						context.Response.StatusCode = 401;
						context.Response.ContentType = "application/json";
						var result = JsonConvert.SerializeObject(new Response<string>("Unauthorized User"));
						return context.Response.WriteAsync(result);
					},
					OnForbidden =  context =>
					{
						context.Response.StatusCode = 400;
                        context.Response.ContentType = "application/json";
						var result = JsonConvert.SerializeObject(new Response<string>("Forbidden User"));
						return context.Response.WriteAsync(result);
                    }
				};
			});
        }
	}
}

