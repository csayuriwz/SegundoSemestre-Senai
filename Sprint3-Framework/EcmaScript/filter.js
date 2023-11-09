// //filter - RETORNA UM ARRAY SOMENTE COM ELEMENTOS QUE ATENDERAM UMA CONDICAO
// const numeros = [2,4,6,8,12];

// const maior10 = numeros.filter((e) => {
//     return e > 10
// });

// console.log(maior10);


const comentarios = [
    {comentario: "bla bla bla", exibe: true},
    {comentario: "evento foi uma", exibe: false},
    {comentario: "Otimo evento!", exibe: true},
]

const comentariosOK = comentarios.filter((c) => {
    return c.exibe == true;
})

comentariosOK.forEach((c) => {
    console.log(c.comentario);
})
;

