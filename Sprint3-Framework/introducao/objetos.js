//objeto literal
let catarina =  {
    nome: "Catarina",
    idade: 16,
    altura: 1.66
};

catarina.peso = 50

//o console serve p testar
console.log(catarina);


//OUTRO JEITO DE CRIRA, DINAMICO, COLOCANDO ATRIBUTOS APOS A CRIACAO DO OBJETO.

let bianca = new Object();

bianca.nome = "Bianca";
bianca.idade = 16,
bianca.sobrenome = "Cardenas";

console.log(bianca);

let pessoas = [];
pessoas.push(catarina);
pessoas.push(bianca);

console.log(pessoas);

pessoas.forEach(function(v,i) {
    console.log(`Nome ${i+1}: ${v.nome}`);
});

