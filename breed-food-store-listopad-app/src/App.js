import { React } from "react";
import "./App.css";
import Categories from './components/pages/Categories/Categories';
import { BrowserRouter } from "react-router-dom";
import AppRouter from './router/AppRouter/AppRouter';

function App() {
    return (
        <div>
            <BrowserRouter>
                <AppRouter />
            </BrowserRouter>
        </div>
    );
}

export default App;