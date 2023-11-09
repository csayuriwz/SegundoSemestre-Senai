import React from 'react';
import './VisionSection.css';
import Title from '../Title/Title';

const VisionSection = () => {
    return (
        <section className='vision'>
            <div className='vision__box'>
                <Title 
                 titleText={"Visão"}
                 color='white'
                 additionalClass='vision__title'
                />
                <p className='vision__text'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Iste recusandae a non similique porro accusantium consequuntur eaque natus, odit accusamus corporis voluptatum ad et optio fugit nisi cumque eius dolore. Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet nam dolor autem. Corrupti pariatur consectetur, quia architecto delectus sapiente eos facilis placeat, laudantium, quos ut ratione dolores nulla quod doloremque.</p>
            </div>

        </section>
    );
};

export default VisionSection;