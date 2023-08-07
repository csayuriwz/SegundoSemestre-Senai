--DML
USE Exercicio_1_4T;

INSERT INTO Artistas(Nome)
VALUES('Luan Santana')

INSERT INTO Artistas(Nome)
VALUES('Billie Eilish')

INSERT INTO Albuns(IdArtista, Titulo, DataLancamento, Localizacao, QtdMin, Ativo)
VALUES(1, 'Meteoro', '19-01-2021', 'São Caetano - SP', '52:48', 1)

INSERT INTO GenerosMsc(Nome)
VALUES('PoP')

INSERT INTO GenerosMsc(Nome)
VALUES('MPB')

INSERT INTO EstiloMusical(IdAlbum, IdGenero)
VALUES(1,1)

INSERT INTO Usuarios(Nome, Email, Senha, Permissao)
VALUES('Catarina Sayuri', 'catarina.sayuri@gmail.com', 'senai@126', 1)

Select * from Artistas