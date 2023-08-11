--DQL criar scriptpara consukta exibindo os seguintes dados (JOIN)

/*
Nome do usuario
Tipo do usuario
Data do evento
Local do evento(instituicao)
Tipo de evento
Nome do evento
Descricao do evento
Situacao do Evento
Comentario do evento
*/

SELECT

	Usuario.Nome                                                                       AS [Nome do Usuario],
	TiposDeUsuario.TituloTipoUsuario                                                   AS [Tipo do Usuário],
	Eventos.DataEvento                                                                  AS [Data do Evento],
	CONCAT(Instituicao.NomeFantasia,' ',Instituicao.Endereco)                          AS 'Local',
	TiposDeEventos.Titulo                                                     AS [Tipo do Evento],
	Eventos.Nome                                                                        AS [Nome do Evento],
	Eventos.Descricao                                                                   AS [Descrição do Evento],
	CASE WHEN PresencasEvento.Situacao = 1 THEN 'Confirmada' ELSE 'Não Confirmada' END AS[Situação],
	ComentarioEvento.Descricao                                                         AS [Comentário]

FROM Eventos
	INNER JOIN TiposDeEventos	ON Eventos.IdTiposDeEventos = TiposDeEventos.IdTiposDeEventos
	INNER JOIN Instituicao		ON Eventos.IdInstituicao = Instituicao.IdInstituicao
	INNER JOIN PresencasEvento	ON Eventos.IdEventos = PresencasEvento.IdEventos
	INNER JOIN Usuario		    ON PresencasEvento.IdUsuario = Usuario.IdUsuario
	INNER JOIN TiposDeUsuario	ON TiposDeUsuario.IdTiposDeUsuario = Usuario.IdTiposDeUsuario
	LEFT JOIN ComentarioEvento	ON ComentarioEvento.IdUsuario = Usuario.IdUsuario






