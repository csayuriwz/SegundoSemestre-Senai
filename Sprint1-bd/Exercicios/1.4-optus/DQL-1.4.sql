--DQL - listar todos os usu�rios administradores, sem exibir suas senhas
-- listar todos os �lbuns lan�ados ap�s o um determinado ano de lan�amento
-- listar os dados de um usu�rio atrav�s do e-mail e senha
-- listar todos os �lbuns ativos, mostrando o nome do artista e os estilos do �lbum 

CREATE DATABASE Exercicio_1_4;

USE Exercicio_1_4T;


SELECT 
Usuarios.Nome AS USU�RIO, 
Usuarios.Email AS EMAIL

FROM Usuarios 
WHERE Usuarios.Permissao = 1
 


SELECT 
Albuns.IdAlbum AS ID,
Albuns.Titulo AS T�TULO,
Albuns.DataLancamento AS LAN�AMENTO,
Albuns.Localizacao AS LOCALIZA��O,
Albuns.QtdMin AS MINUTOS,
Albuns.Ativo AS ATIVO

FROM Albuns
WHERE Albuns.DataLancamento >= '02-09-1986'


SELECT 

Usuarios.IdUsuario AS IDUSER,
Usuarios.Nome AS NOME,
Usuarios.Permissao AS PERMISS�O

FROM Usuarios
WHERE Usuarios.Email = 'catarina.sayuri@gmail.com' AND Senha = 'senai@126'

SELECT 

Albuns.IdAlbum AS ID,
Albuns.Titulo AS T�TULO,
Albuns.DataLancamento AS LAN�AMENTO,
Albuns.Localizacao AS LOCALIZA��O,
Albuns.QtdMin AS MINUTOS,
Albuns.Ativo AS ATIVO

FROM Albuns
WHERE Albuns.Ativo = 1