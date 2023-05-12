import { React, useState } from "react";
import "./App.css";
import { BrowserRouter } from "react-router-dom";
import AppRouter from './router/AppRouter/AppRouter';
import { Context } from './context/context';

function App() {
    const [notifications, setNotifications] = useState([])
    return (
        <div>
            <Context.Provider value={{ notifications: notifications, setNotifications: setNotifications }}>
                <BrowserRouter>
                    <AppRouter />
                </BrowserRouter>
            </Context.Provider>
        </div>
    );
}

export default App;