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

const TipoEventosPage = () => {
  const [frmEdit, setFrmEdit] = useState(false);
  const [titulo, setTitulo] = useState("");
  const [typeEvents, setTypeEvents] = useState([])

  useEffect(() => {
    // chamar a api
    async function getTipoEventos() {
      try {
        const promise = await api.get("/TiposEvento");

        setTypeEvents(promise.data);

      } catch (error) {
        console.log(error);
        alert("Deu ruim na api");
      }
    } getTipoEventos();

   
  }, []);

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
  function handleUpdate() {
    alert("Bora Atualizar");
  }

  //mostra a forma atualizada
  function showUpdate(tipoEvento) {
    try {
      //busca o input (form)
      
    } catch (error) {
      
    }
  }

  function editActionAbort() {
    alert("Cancelar a tela de edicao de dados");
  }

  function handleDelete() {
    alert("Bora la apagar na api");
  }
  return (
    <MainContent>
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
              {!frmEdit ? (
                /* Cadastrar*/
                <>
                  <Input
                    type={"text"}
                    id={"titulo"}
                    name={"titulo"}
                    placeholder={"Título"}
                    required={"required"}
                    value={titulo}
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />
                  <span>{titulo}</span>

                  <Button
                    type={"submit"}
                    id={"cadastrar"}
                    name={"cadastrar"}
                    textButton={"Cadastrar"}
                  />
                </>
              ) : (
                <p>Tela de Edicao</p>
              )}

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
            dados={typeEvents}
            fnUpdate={showUpdate}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default TipoEventosPage;
