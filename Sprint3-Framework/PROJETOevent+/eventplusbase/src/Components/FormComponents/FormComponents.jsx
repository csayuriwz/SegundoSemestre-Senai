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