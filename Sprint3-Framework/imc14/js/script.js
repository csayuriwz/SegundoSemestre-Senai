const listaPessoas = []; //undefined

function calcular(e) 
{
    e.preventDefault();

    let nome = document.getElementById("nome").value.trim() ;
    let altura = parseFloat(document.getElementById("altura").value );
    let peso = parseFloat(document.getElementById("peso").value );

    if(isNaN(altura) || isNaN(peso) || nome.length < 2)
    {alert("É necessário preencher todos os campos corretamente") 
    return;
    }

    const imc = calcularImc(peso, altura);    
    const txtSituacao = geraSituacao(imc);

    const pessoa = {
        nome, //: nome, quando o nome da variavel e o mesmo do objeto voce pode retira-lo
        altura, //: altura,
        peso, //: peso,
        imc, //: imc,
        situacao : txtSituacao
    }

            //cadastra na lista de pessoas
            listaPessoas.push(pessoa);
            localStorage.setItem("listaPessoas", JSON.stringify(listaPessoas));
            //exibir a pessoa na tela
            exibirPessoas();

}

function calcularImc(peso , altura) 
{
    return peso / Math.pow(altura, 2);
    // return peso / (altura * altura);    
    // return peso / (altura ** 2);    
}


function geraSituacao(imc) 
{
    if (imc <= 18.5) 
    {
        return "Abaixo do Peso"
    }
    else if (imc <= 24.9) 
    {
        return "Peso Ideal"
    }
    else if (imc <= 29.9) 
    {
        return "Acima do Peso"
    }
    else if (imc <= 34.9) 
    {
        return "Obesidade I"
    }
    else if (imc <= 39.9 ) 
    {
        return "Obesidade II"
    }
    else if (imc >= 40 ) 
    {
        return "Obesidade III"
    }
    
}   

if (localStorage.getItem("listaPessoas") == null) { //não tem dados
    listaPessoas = []; //inicializa com array vazio

} else {
    listaPessoas = JSON.parse(localStorage.getItem("listaPessoas"));
}

exibirPessoas(); //roda a função pra exibir os cadastros, caso existam
    /* <tr>
    <td>Matheus</td>
    <td>1.68</td>
    <td>60</td>
    <td>21</td>
    <td>Peso Ideal</td>
    </tr> */
function exibirPessoas() {
    let linhas = "";

    listaPessoas.forEach(function (oPessoa) {
        //linhas de tabela
        linhas += `
        <tr>
        <td>${oPessoa.nome}</td>
        <td>${oPessoa.altura}</td>
        <td>${oPessoa.peso}</td>
        <td>${oPessoa.imc.toFixed(2)}</td>
        <td>${oPessoa.situacao}</td>
        </tr>
        `;
        document.getElementById('cadastro').innerHTML = linhas;
    })
}
