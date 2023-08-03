--DQL - listar todos os usuários administradores, sem exibir suas senhas
-- listar todos os álbuns lançados após o um determinado ano de lançamento
-- listar os dados de um usuário através do e-mail e senha
-- listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum 

CREATE DATABASE Exercicio_1_4;

USE Exercicio_1_4;


SELECT 
Usuarios.Nome AS USUÁRIO, 
Usuarios.Email AS EMAIL

FROM Usuarios 
WHERE Usuarios.Permissao = 1
 


SELECT 
Albuns.IdAlbum AS ID,
Albuns.Titulo AS TÍTULO,
Albuns.DataLancamento AS LANÇAMENTO,
Albuns.Localizacao AS LOCALIZAÇÃO,
Albuns.QtdMin AS MINUTOS,
Albuns.Ativo AS ATIVO

FROM Albuns
WHERE Albuns.DataLancamento >= '01-01-2000'


SELECT 

Usuarios.IdUsuario AS IDUSER,
Usuarios.Nome AS NOME,
Usuarios.Permissao AS PERMISSÃO

FROM Usuarios
WHERE Usuarios.Email = 'rebeca@rebeca.com' AND Senha = 'senai@134'

SELECT 

Albuns.IdAlbum AS ID,
Albuns.Titulo AS TÍTULO,
Albuns.DataLancamento AS LANÇAMENTO,
Albuns.Localizacao AS LOCALIZAÇÃO,
Albuns.QtdMin AS MINUTOS,
Albuns.Ativo AS ATIVO

FROM Albuns
WHERE Albuns.Ativo = 1