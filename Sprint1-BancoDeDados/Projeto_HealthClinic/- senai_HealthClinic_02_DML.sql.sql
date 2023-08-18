--DML- INSERIR DADOS NAS TABELAS

USE HEALTH_CLINIC_T;

INSERT INTO TipoUsuario(Tipo)
VALUES ('Paciente');

SELECT * FROM TipoUsuario

INSERT INTO Especialidade(Tipo)
VALUES ('Pediatra')

SELECT * FROM Especialidade

INSERT INTO Usuario(IdTipoUsuario, Nome,Senha,Email)
VALUES (3, 'kiara', '1562','kiara@gmail.com')

SELECT * FROM Usuario

INSERT INTO Paciente (IdUsuario,CPF,RG, CEP,Endereco,Telefone)
VALUES (3,'12333783582','1209787234', '142568372', 'Rua Boa Vista 321', '12543456')

SELECT * FROM Paciente

INSERT INTO Clinica (Endereco,HorarioFuncionamento,CNPJ,NomeFantasia,RazaoSocial)
VALUES ('Rua Niteroi 801', '07:00 as 20:00', '5162437', 'Clinica Senai', 'Clinica Medica' )

SELECT * FROM Clinica

INSERT INTO Medico (IdClinica,IdEspecialidade,IdUsuario,CRM)
VALUES (1,1,2,'34878')

SELECT * FROM Medico

INSERT INTO Consulta(IdPaciente,IdFeedback,IdMedico,IdClinica,DataConsulta,HorarioConsulta,Prontuario)
VALUES (2,2,2,1,'12/06/2023', 'as 15horas' )

INSERT INTO Consulta(Prontuario)
VALUES ('Paciente examinado')

SELECT * FROM Consulta

INSERT INTO Feedback(Descricao)
Values ('Tive a oportunidade de realizar uma consulta com a Dra. Camila e fiquei extremamente satisfeita com a experiência.')

SELECT * FROM Feedback


