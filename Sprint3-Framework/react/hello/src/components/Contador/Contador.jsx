import React, { useState } from "react";
import './Contador.css';

const Contador = () => {

    const [contador, setContador] = useState(0)

    function handleIncrementar() {
         setContador(contador + 1);
    }

    function handleDecrementar() {
        contador > 0 ? setContador (contador -1) : alert("Impossivel decrementar de 0")
   }


    return (
        <>
        <p>{contador}</p>
        <button onClick={handleIncrementar}>Incrementar</button>
        <br /> <br />
        <button onClick={handleDecrementar}>Decrementar</button>
        </>
    );
}

export default Contador;