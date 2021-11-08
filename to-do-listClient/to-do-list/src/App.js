import {NavBar} from "./components/NavBar/NavBar";
import styles from './App.module.css';
import {Router} from "./Router";
import {BrowserRouter} from "react-router-dom";
import {useSelector} from "react-redux";
import {userSelector} from "./store/userSlice";
import React from "react";
import Footer from "./components/Footer/Footer";


function App() {
    const user = useSelector(userSelector).user

    return (
        <BrowserRouter>
            <NavBar user={user}/>
            <div className={styles.container}>
                <Router user={user}/>
            </div>
            {/*<Footer/>*/}
        </BrowserRouter>
    );
}

export default App;
