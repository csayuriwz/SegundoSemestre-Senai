--DML

USE Exercicio_1_3;

INSERT INTO Clinica(Nome, Endereco)
VALUES('Senai VET', 'Rua Niterói,180')

INSERT INTO Veterinario(IdClinica, NomeVet)
VALUES(1, 'Carlos Roque')

INSERT INTO TipoPet(Descricao)
VALUES('Gato')

INSERT INTO Raca(Descricao)
VALUES('Siamês')

INSERT INTO Pets(IdRaca, IdTipoPet,IdDono, Nome, DataNascimento)
VALUES(1, 1, 1, 'Nutella', '20-07-2020')

INSERT INTO Dono(Endereco)
VALUES('Ribeirão Pires')

INSERT INTO Atendimento(IdVeterinario, IdPets)
VALUES(1, 1)