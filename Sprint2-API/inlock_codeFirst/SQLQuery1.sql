SELECT * FROM Jogo
SELECT * FROM Estudio
SELECT * FROM Usuario
SELECT * FROM TiposUsuario

INSERT INTO Estudio(IdEstudio,Nome)
VALUES(NEWID(),'Chucklefish')


INSERT INTO Jogo(IdJogo,IdEstudio,Nome,Descricao,DataLancamento,Preco)
VALUES(NEWID(), 'FB04A17A-4011-4858-93A2-A8D53B781B79','Stardew Valley','RPG de simulação onde o player cuida de uma fazenda, se aproximar dos moradores de uma cidade pequena e ajudar a renovar o Centro da Comunidade.','26-02-2016', 0)


INSERT INTO TiposUsuario(IdTipoUsuario,Titulo)
VALUES(NEWID(),'Comum'),(NEWID(),'Administrador')


INSERT INTO Usuario(IdUsuario,IdTipoUsuario,Email,Senha)
VALUES(NEWID(),'F0957C37-0601-473C-BB86-D8EE4C25A4D4','comum@gmail.com','comum1234'),
(NEWID(),'C56A5491-BE36-4A85-83ED-F40AA77F869A','administrador@gmail.com','adm1234')
