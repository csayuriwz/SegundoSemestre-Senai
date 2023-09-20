--DML - INSERIR DADOS NAS TABELAS

USE Exercicio_1_2T;

INSERT INTO Empresa(Nome)
VALUES ('KAVAK')

INSERT INTO Marca(Nome)
VALUES('Chevrolet')

INSERT INTO Modelo(Tipo)
VALUES ('Capitiva')

INSERT INTO Cliente(Nome,CPF)
VALUES ('Catarina Sayuri', '12338456723')

INSERT INTO Veiculos(IdMarca, IdModelo, IdEmpresa, Placa)
VALUES (1, 2, 1, 'ABC123')

INSERT INTO Aluguel(IdCliente,Preco, IdVeiculos)
VALUES (1, 125.000, 6)

SELECT * FROM Empresa
SELECT * FROM Modelo
SELECT * FROM Cliente
SELECT * FROM Veiculos
SELECT * FROM Marca
SELECT * FROM Aluguel