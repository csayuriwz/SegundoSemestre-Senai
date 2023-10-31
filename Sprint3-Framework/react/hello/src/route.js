import React from 'react';
//import dos componentes de rotas
import {BrowserRoute, Routes, Route} from 'react-router-dom';
import HomePage from './Pages/HomePage/HomePage';
import LoginPage from './Pages/LoginPage/LoginPage';
import ProdutoPage from './Pages/Produtopage/ProdutoPage';

//import das paginas
const Rotas = () => {
    return (
        //criar as estruturas de rotas
        <BrowserRoute>
            <Routes>
                <Route element={<HomePage />} path="/" exact />
                <Route element={<LoginPage />} path="/login" />
                <Route element={<ProdutoPage />} path="/produtos" />
            </Routes>
        </BrowserRoute>
    );
};

export default Rotas;