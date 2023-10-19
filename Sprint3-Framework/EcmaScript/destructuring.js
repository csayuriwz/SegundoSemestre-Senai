const tenisNike = {
    descricao: "Tenis Nike",
    preco: 700.00,
    marca: "Nike",
    tamanho: "M",
    cor: "bordo",
    promo: true,

}

const {descricao, preco, promo} = tenisNike

console.log(`
    Produto: ${descricao}
    Preco: ${preco}
    Promocao: ${promo ? "Sim" : "Nao"}
`);

//crie um obj evento com as propriedades, data evento,descricao evento, titulo, presenca, comentario, crie uma distructuring das propriedades do objeto evento e as exiba no console. obs a presenca deve exibir sim ou nao

const evento = {
    dataEvento: "31/10",
    descricaoEvento: "Festa de Halloween",
    Titulo: "Halloween",
    presenca: true,
    comentario: "a festa nao ocorreu ainda",
}

const {dataEvento, descricaoEvento,Titulo,presenca, comentario} = evento

    	
console.log(`
    data do evento: ${dataEvento}
    descricao: ${descricaoEvento}
    Titulo: ${Titulo}
    Presenca: ${presenca ? "Confirmada" : "Nao Confirmada"}
    comentario: ${comentario}
`);