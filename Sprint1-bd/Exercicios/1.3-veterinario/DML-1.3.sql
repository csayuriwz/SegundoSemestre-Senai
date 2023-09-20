--DML

USE Exercicio_1_3T;

INSERT INTO Clinica(Endereco)
VALUES('Rua Niterói,180')

INSERT INTO Veterinario(IdClinica, NomeVet)
VALUES(1, 'Carolina')

INSERT INTO TipoPet(Descricao)
VALUES('Gato')

INSERT INTO Raca(Descricao)
VALUES('Persa')

INSERT INTO Pet(IdRaca, IdTipoPet,IdDono, Nome, DataNascimento)
VALUES(2, 2, 2, 'Frida', '26/04/2022')

INSERT INTO Dono(Nome,Telefone)
VALUES('Bianca Cardenas', '911452345')

INSERT INTO Atendimento(IdVeterinario, IdPet)
VALUES(2, 5)


SELECT * FROM Atendimento
SELECT * FROM Dono
SELECT * FROM Pet
SELECT * FROM Raca
SELECT * FROM TipoPet
SELECT * FROM Clinica
SELECT * FROM Veterinario