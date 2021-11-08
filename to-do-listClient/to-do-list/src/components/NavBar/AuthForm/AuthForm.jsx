import React, {useState} from "react";
import {Button} from "../../../UI/Button/Button";
import {Input} from "../../../UI/Input/Input";
import styles from './AuthForm.module.css'

export const AuthForm = ({validationHandler, isLogin}) => {
    const [form, setForm] = useState({})

    const action = (e) => {
        e.preventDefault()
        if (Object.keys(form).length === 4)
            validationHandler(form, false)
        else
            validationHandler(form, true)
    }

    const changeHandler = event => {
        setForm({...form, [event.target.name]: event.target.value})
    }

    const loginSample = <>
        <Input name="username" value={form.username} onChange={changeHandler} type="text" placeholder="Username"/>
        <Input name="password" value={form.password} onChange={changeHandler} type="password" placeholder="Password"/>
    </>
    const registrationSample = <>
        <Input name="firstname" value={form.firstname} onChange={changeHandler} type="text" placeholder="Firstname"/>
        <Input name="lastname" value={form.lastname} onChange={changeHandler} type="text" placeholder="Lastname"/>

    </>
    return (
        <form className={styles.authForm}>
            {!isLogin ?
                registrationSample : null}
            {loginSample}
            <Button
                //disabled={loading}
                    onClick={action}>{isLogin ? "Login"
                : "Register"}</Button>
        </form>
    )
}
