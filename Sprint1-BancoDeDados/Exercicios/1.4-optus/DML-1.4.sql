--DML
USE Exercicio_1_4T;

INSERT INTO Artistas(Nome)
VALUES('Luan Santana')

INSERT INTO Artistas(Nome)
VALUES('Billie Eilish')

INSERT INTO Albuns(IdArtista, Titulo, DataLancamento, Localizacao, QtdMin, Ativo)
VALUES(1, 'Senai', '29-05-2020', 'São Caetano - SP', '10:32', 1)

INSERT INTO GenerosMsc(Nome)
VALUES('PoP')

INSERT INTO GenerosMsc(Nome)
VALUES('MPB')

INSERT INTO EstilosMsc(IdAlbum, IdGenero)
VALUES(2, 2)

INSERT INTO Usuarios(Nome, Email, Senha, Permissao)
VALUES('Rebeca Carolina', 'rebeca@rebeca.com', 'senai@134', 1)