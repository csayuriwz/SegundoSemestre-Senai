USE Exercicio_1_2T;

SELECT Cliente.IdCliente, Cliente.Nome, Modelo.Tipo
FROM Aluguel
LEFT JOIN Cliente ON Cliente.IdCliente = AlugueL.IdCliente
LEFT JOIN Veiculos ON Veiculos.IdVeiculos = Veiculos.IdModelo 
LEFT JOIN Modelo ON Modelo.IdModelo = Veiculos.IdModelo
WHERE Cliente.IdCliente = 1;


SELECT 

Cliente.Nome AS Nome,
Modelo.Tipo AS Modelo
FROM
Aluguel
LEFT JOIN 
Modelo ON Aluguel.IdVeiculos = Modelo.IdModelo
LEFT JOIN 
Cliente ON Aluguel.IdCliente = Cliente.IdCliente

WHERE Cliente.IdCliente = 1;