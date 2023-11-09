import React from 'react';
import {Link} from "react-router-dom";
const Header = () => {
    return (
        <header>
            <nav>
                 <Link to="/">Home</Link>
                <br />
                <Link to="/tipo-eventos">Tipo Evento</Link>
                <br />
                <Link to="/eventos">Eventos</Link>
                <br />
                <Link to="/login">Login</Link>
                <br />
                <Link to="/testes">Teste</Link>
            </nav>
        </header>
    );
};

export default Header;