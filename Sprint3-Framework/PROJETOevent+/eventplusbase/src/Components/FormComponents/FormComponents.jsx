import React from 'react';
import './FormComponents.css'



export const Input = ({
    type,
    id,
    required,
    aditionalClass,
    name,
    value,
    placeholder,
    manipulationFunction
}) => {
    return (
        <input 
        type={type}
        id={id}
        value={value}
        name={name}
        required={required}
        className={`input-component ${aditionalClass}`}
        placeholder={placeholder}
        onChange={manipulationFunction}
        autoComplete='off'
        

        />
    );
}

export const Button = ({textButton,id, name, type, additionalClass = "", manipulationFunction}) => {
    return (
        <button     
            type={type}
            name={name}
            id={id}
            className={`button-component ${additionalClass}`}
            onClick={manipulationFunction}
        >
            {textButton}
        </button>
    );
}


export const Select = ({
    tipoEventos = [],
    id,
    name,
    required,
    additionalClass,
    manipulationFunction,
    defaultValue
}) => {
    return (
        <select 
        name={name}
        id={id}
        required={required}
        className={`input-component ${additionalClass}`}
        onChane={manipulationFunction}
        value={defaultValue}>
            <option value="">Selecione</option>
            {tipoEventos.map((opt) => {
                return <option value={opt.titulo}>{opt.titulo}</option>
            })}
        </select>
    );
}