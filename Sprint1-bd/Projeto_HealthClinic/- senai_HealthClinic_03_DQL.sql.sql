--DQL

use HEALTH_CLINIC_T

/*Criar script com os seguintes dados:
-Id Consulta
-Data da consulta
-Horario da consulta
-Nome da clinica
-Nome do paciente
-Nome do medico
-CRM
-Prontuario ou descricao
-Feedback(comentario da consulta)

Criar funcao para retornar os medicos de uma determinada especialidade

criar prodecure para retornar a idade de um determinado usuario especifico
*/

SELECT

Consulta.IdConsulta AS [Id da consulta],
Consulta.DataConsulta AS [Data da consulta],
Consulta.HorarioConsulta AS [Hora da consulta],
Clinica.NomeFantasia AS [Clinica],
UsuarioPaciente.Nome,
UsuarioMedico.Nome,
Medico.CRM AS [CRM],
Consulta.Prontuario AS [Prontuario],
Feedback.Descricao AS [Feedback]

FROM Consulta
left JOIN Medico ON Consulta.IdMedico = Medico.IdMedico
left join Clinica on Medico.IdClinica = Clinica.IdClinica
left JOIN Paciente on Consulta.IdPaciente = Paciente.IdPaciente
left join Usuario AS UsuarioPaciente on Paciente.IdUsuario = UsuarioPaciente.IdUsuario
left JOIN Usuario as UsuarioMedico on Medico.IdUsuario = UsuarioMedico.IdUsuario
left join Feedback on Consulta.IdFeedback = Feedback.IdFeedback









SELECT * FROM Consulta











--FUNCOES: 

CREATE FUNCTION BuscaMedico
(
	@especialidade VARCHAR (100)
)

RETURNS TABLE
AS RETURN
(
SELECT 
MedicoUsuario.Nome AS [Nome do medico],
Especialidade.Tipo AS [Especialdade]

FROM
Especialidade
INNER JOIN
Medico ON Especialidade.IdEspecialidade = Medico.IdEspecialidade
INNER JOIN
Usuario AS MedicoUsuario ON Medico.IdUsuario = MedicoUsuario.IdUsuario
WHERE Especialidade.Tipo = @especialidade
)


SELECT * FROM BuscaMedico ('Cardiologista')



SELECT * FROM Medico
SELECT * FROM Especialidade
