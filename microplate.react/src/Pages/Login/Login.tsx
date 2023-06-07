import { useRef } from 'react';

import { loginAction } from 'Actions/AuthActions';
import './Login.css';


export default function Login() {
    const usernameRef = useRef<HTMLInputElement>(null);
    const passwordRef = useRef<HTMLInputElement>(null);
    const a = setTimeout(() => { }, 10000);
    async function login() {
        await loginAction({ userName: usernameRef.current?.value, password: passwordRef.current?.value });
    }
    return (
        <div className="login-wrapper">
            <h1>Please Log In</h1>
            <form>
                <label>
                    <p>Username</p>
                    <input type="text" ref={usernameRef} />
                </label>
                <label>
                    <p>Password</p>
                    <input type="password" ref={passwordRef} />
                </label>
                <div>
                    <button type="button" onClick={login}>Submit</button>
                    {process.env.REACT_APP_LOGIN_BASE_URL}
                </div>
            </form>
        </div>
    )
}
