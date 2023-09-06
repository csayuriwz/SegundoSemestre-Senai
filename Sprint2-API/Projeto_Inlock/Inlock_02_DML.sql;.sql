USE inlock_games_Tarde;
GO

INSERT INTO Estudio(Nome)
VALUES ('Blizzard'),('Rockstar Studios'),('Square Enix');
GO

INSERT INTO Jogo(IdEstudio,Nome,Descricao,DataLancamento,Valor)
VALUES (1,'Diablo 3','é um jogo que contêm bastante açõo e é viciante, seja você um novato ou um fã.','2012-09-24','99')
	  ,(2,'Red Dead Redemption II','Jogo eletrônico de ação-aventura western.','2012-09-27','120');
GO

INSERT INTO TiposUsuario(Titulo)
VALUES ('Comum'),('Administrador');
GO

INSERT INTO Usuario(IdTipoUsuario,Email,Senha)
VALUES (1,'cliente@cliente.com','cliente')
      ,(2,'admin@admin.com','admin');
GO