--DML
USE Exercicio_1_4;

INSERT INTO Artistas(Nome)
VALUES('Carlos Roque')

INSERT INTO Artistas(Nome)
VALUES('Eduardo Costa')

INSERT INTO Albuns(IdArtista, Titulo, DataLancamento, Localizacao, QtdMin, Ativo)
VALUES(1, 'Senai', '29-05-2020', 'São Caetano - SP', '10:32', 1)

INSERT INTO GenerosMsc(Nome)
VALUES('Rock')

INSERT INTO GenerosMsc(Nome)
VALUES('Samba')

INSERT INTO EstilosMsc(IdAlbum, IdGenero)
VALUES(2, 2)

INSERT INTO Usuarios(Nome, Email, Senha, Permissao)
VALUES('Rebeca Carolina', 'rebeca@rebeca.com', 'senai@134', 1)