import React from 'react';

const Button = (props) => {
    return (
        <button type={props.type}>
            {props.nomeBotao}
        </button>
    );
};

export default Button;