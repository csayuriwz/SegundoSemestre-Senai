import React from 'react';
import "./ImageIllustrator.css"

import imageDefalut from "../../assets/images/default-image.jpeg"

const ImageIllustrator = ( {alterText, imageRender=imageDefalut, additionalClass = "" } ) => {
    return (
       <figure className='illustrator-box'>
            <img 
            src={imageRender} 
            alt={alterText}
            className={`illustrator-box__image ${additionalClass}`}
            />
            
       </figure>
    );
};

export default ImageIllustrator;