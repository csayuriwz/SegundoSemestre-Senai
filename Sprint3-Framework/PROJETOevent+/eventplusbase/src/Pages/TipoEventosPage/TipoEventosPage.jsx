import React, { useState, useEffect } from "react";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";

import eventTypeImage from "../../assets/images/tipo-evento.svg";
import Container from "../../Components/Container/Container";
import { Button, Input } from "../../Components/FormComponents/FormComponents";

import api from "../../Services/Service";
import TableTp from "./TableTp/TableTp";

import Notification from "../../Components/Notification/Notification";

const TipoEventosPage = () => {
  const [frmEdit, setFrmEdit] = useState(false);
  const [notifyUser, setNotifyUser] = useState({});
  const [titulo, setTitulo] = useState("");
  const [tipoEvento, setTipoEvento] = useState([]);
  const [tipoEventoSelecionado, setTipoEventoSelecionado] = useState("");

  useEffect(() => {
    // chamar a api
    async function getTipoEventos() {
      try {
        const promise = await api.get("/TiposEvento");

        setTipoEvento(promise.data);

        <Notification {...notifyUser} setNotifyUser={setNotifyUser} />;

        setNotifyUser({
          titleNote: "Sucesso",
          textNote: `Cadastrado com sucesso!`,
          imgIcon: "success",
          imgAlt:
            "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
          showMessage: true,
        });
      } catch (error) {
        console.log(error);
        alert("Deu ruim na api");
      }
    }
    getTipoEventos();
  }, [tipoEvento]);

  async function handleSubmit(e) {
    //parar o submit do formulario
    e.preventDefault();
    //validar plmns 3 caracteres
    if (titulo.trim().length < 3) {
      alert("O titulo deve ter no minimo 3 carecteres ");
      return;
    }
    //chamar a api

    try {
      const retorno = await api.post("/TiposEvento", { titulo: titulo });
      console.log("CADASTRADO COM SUCESSO");
      console.log(retorno.data);
      setTitulo(""); //limpa a variavel
    } catch (error) {
      console.log("Deu ruim na api");
      console.log(error);
    }
  }

  //ATUALIZACAO DOS DADOS
  //(mostra a tela de edicao)
  async function handleUpdate(e) {
    e.preventDefault();

    if (titulo.trim().length < 3) {
      alert("O titulo deve ter plmns 3 caracteres");

      return;
    }

    try {
      const retorno = await api.put(
        `/TiposEvento/${tipoEventoSelecionado.idTipoEvento}`,
        { titulo: titulo }
      );
      console.log("Atualizado com sucesso");
      console.log(retorno.data);
      setTitulo("");
    } catch (error) {
      console.log("erro");
    }
  }

  //mostra a forma atualizada
  async function showUpdate(tipoEvento) {
    setFrmEdit(true);
    setTipoEventoSelecionado(tipoEvento);
    console.log(tipoEvento);
    try {
      //busca o input (form)
      const inputEdit = document.getElementById("titulo");

      inputEdit.value = await tipoEvento.titulo;

      const cadastrarBotao = document.getElementById("Cadastrar");

      cadastrarBotao.textContent = "Atualizar";
    } catch (error) {
      alert(`ocorreu um erro ${error}`);
    }
  }

  function editActionAbort() {
    alert("Cancelar a tela de edicao de dados");
  }

  async function handleDelete(idEvento) {
    try {
      const retorno = await api.delete(`/TiposEvento/${idEvento}`);
    } catch (error) {
      console.log(error);
      alert("erro ao excluir");
    }
  }
  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {/* Cadastro de tipo de eventos*/}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Página Tipos de Eventos"} />
            <ImageIllustrator alterText={"???"} imageRender={eventTypeImage} />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              {/* {!frmEdit ? ( */}

              <>
                <Input
                  type={"text"}
                  id={"titulo"}
                  name={"titulo"}
                  placeholder={"Titulo"}
                  required={"required"}
                  value={titulo}
                  manipulationFunction={(e) => {
                    setTitulo(e.target.value);
                  }}
                />
                <span>{titulo}</span>

                <Button
                  type={"submit"}
                  id={"Cadastrar"}
                  name={"cadastrar"}
                  textButton={"Cadastrar"}
                />
              </>
              {/* ) : (
                <p>Tela de Edicao</p>
              )} */}

              {/* Atualizar  */}
            </form>
          </div>
        </Container>
      </section>

      {/* Listagem de tipos de eventos */}
      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista Tipo de Eventos"} color="white" />

          <TableTp
            dados={tipoEvento}
            fnUpdate={showUpdate}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default TipoEventosPage;
