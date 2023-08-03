--DML - INSERIR DADOS NAS TABELAS

USE Exercicio_1_1;

--INSERIR DADOS NA TABELA
INSERT INTO Pessoa(Nome,CNH)
VALUES('Catarina','1234512890'),('Bianca','0985654921')

--INSERT INTO Pessoa VALUES('Carlos','1234567890')

-----------------------------------------------------------

INSERT INTO Email(IdPessoa,Endereco)
VALUES(1,'CatarinaS@gmail.com'),(2,'Biianca@gmail.com')

-----------------------------------------------------------

INSERT INTO Telefone(IdPessoa,Numero)
VALUES(1,'929826254'),(2,'912649267')

INSERT INTO Pessoa
values
	('Mariana', '6153829'),
	('Carolina', '61456829'),
	('Julia', '6153569'),
	('Camila', '5723829');
	



SELECT * FROM Pessoa;
SELECT * FROM Email;
SELECT * FROM Telefone;