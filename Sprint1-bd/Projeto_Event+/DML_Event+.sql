--DML - Data Manipulation Language

INSERT INTO TiposDeUsuario(TituloTipoUsuario) VALUES('Comum')

INSERT INTO TiposDeEventos(Titulo) VALUES('SQL Server');

INSERT INTO Instituicao(NomeFantasia,Endereco,CNPJ) VALUES('DevSchool','Rua Niteroi, 180','56440116000104');

INSERT INTO Usuario(IdTiposDeUsuario,Nome,Email,Senha)
VALUES(1,'Eduardo','eduardo@gmail.com','1234'),(2,'Carlos','carlos@gmail.com','4321');

INSERT INTO Eventos(IdTiposDeEventos,IdInstituicao,Nome,Descricao,DataEvento,HorarioEvento)
VALUES(1,1,'SQL Server e suas funcionalidades', 'Falar sobre as funcionalidades do SQL Server e ensinar como utiliza-las','2023-08-15','20:30:00');

INSERT INTO PresencasEvento(IdUsuario,IdEventos,Situacao) VALUES(2,1,1),(3,1,0);

INSERT INTO ComentarioEvento(IdUsuario,IdEventos,Descricao,Exibe)
VALUES(2,1,'Gostei muito do evento e consegui aprender mais do que imaginava! Grato a todos que estavm presentes.', 1),
(3,1,'Não estive presente no evento', 1)

----------------------------------------------
--SELECT

SELECT * FROM TiposDeUsuario
SELECT * FROM TiposDeEventos
SELECT * FROM Instituicao
SELECT * FROM Usuario
SELECT * FROM Eventos
SELECT * FROM PresencasEvento
SELECT * FROM ComentarioEvento
