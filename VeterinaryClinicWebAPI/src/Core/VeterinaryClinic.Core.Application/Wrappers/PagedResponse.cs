﻿using System;
namespace VeterinaryClinic.Core.Application.Wrappers
{
	public class PagedResponse<T> : Response<T>
	{
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = string.Empty;
            this.Succeeded = true;
            this.Error = null;
            
        }
	}
}

