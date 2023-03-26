import React, { useState } from "react"

export const UserForm = () => {
  const [login, setLogin] = useState({
    email: "",
    password: ""
  })

  function handleSubmit(event: React.SyntheticEvent<HTMLFormElement>) {
    event.preventDefault()
    console.log(event.currentTarget.elements)
  }

  return (
    <form onSubmit={handleSubmit}>
      <input placeholder='Email' value={login.email} autoComplete='off'/>
      <input
        placeholder='Password'
        type='password'
        value={login.password}
        autoComplete='off'
       
      />
      <button>Login</button>
    </form>
  )
}
