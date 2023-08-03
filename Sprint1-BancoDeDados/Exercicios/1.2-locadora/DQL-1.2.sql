USE Exercicio_1_2;

SELECT Cliente.IdCliente, Cliente.Nome, Aluguel.DataRetirada, Aluguel.DataDevolucao, Modelo.Nome
FROM Aluguel
LEFT JOIN Cliente ON Cliente.IdCliente = AlugueL.IdCliente
LEFT JOIN Veiculo ON Veiculo.IdVeiculo = Veiculo.IdModelo 
LEFT JOIN Modelo ON Modelo.IdModelo = Veiculo.IdModelo
WHERE Cliente.IdCliente = 1;


SELECT 

Cliente.Nome AS Nome,
Aluguel.DataRetirada AS Retirada,
Aluguel.DataDevolucao AS Devolução,
Modelo.Nome AS Modelo
FROM
Aluguel
LEFT JOIN 
Modelo ON Aluguel.IdVeiculo = Modelo.IdModelo
LEFT JOIN 
Cliente ON Aluguel.IdCliente = Cliente.IdCliente

WHERE Cliente.IdCliente = 1;