const numeros = [2,4,6,8,12];

const soma = numeros.reduce(( VlInicial, n) => {
    return VlInicial + n
},0)

console.log(soma);