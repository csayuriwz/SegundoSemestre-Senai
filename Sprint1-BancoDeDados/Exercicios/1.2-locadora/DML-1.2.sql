--DML - INSERIR DADOS NAS TABELAS

USE Exercicio_1_2;

INSERT INTO Empresa(Nome)
VALUES ('Senai')

INSERT INTO Marca(Nome)
VALUES('Fiat')

INSERT INTO Modelo(Nome)
VALUES ('Uno')

INSERT INTO Cliente(Nome,CPF)
VALUES ('Rebeca Carolina', '11122233344')

INSERT INTO Veiculo(IdMarca, IdModelo, IdEmpresa, Placa)
VALUES (1, 1, 1, 'AAA-AAAA')

INSERT INTO Aluguel(IdCliente, IdVeiculo, DataRetirada, DataDevolucao)
VALUES (1, 1, '2023-08-01', '2024-01-01')