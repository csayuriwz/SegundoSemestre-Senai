import React, { useEffect, useState } from "react";
import Title from "../../Components/Title/Title";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import eventTypeImage from "../../assets/images/tipo-evento.svg";
import Container from "../../Components/Container/Container";
import { Button, Input } from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Service";
import "./TipoEventosPage.css";
import TableTp from "../TipoEventosPage/TableTp/TableTp";
import Notification from "../../Components/Notification/Notification";
import Spinner from "../../Components/Spinner/Spinner";

const TipoEventosPage = () => {
  const [notifyUser, setNotifyUser] = useState({});
  const [frmEdit, setFrmEdit] = useState(true);
  const [titulo, setTitulo] = useState("");
  const [tipoEventos, setTipoEventos] = useState([]); //array
  const[showSpinner, setShowSpinner] = useState(true);
  const [idEvento, setIdEvento] = useState(null);


  useEffect(() => {
    async function getTiposEvento() {
      setShowSpinner(true)
      try {
        const promise = await api.get("/TiposEvento");
        setTipoEventos(promise.data);
      } catch (error) {
        console.log("Deu ruim na api");
      }
      setShowSpinner(false)
    }
    getTiposEvento();
  }, []);

  async function handleSubmit(e) {
    //parar o submit do formulario
    e.preventDefault();
    //validar pelo menos 3 caracteres
    if (titulo.trim().length < 3) {
      setNotifyUser({
        titleNote: "Aviso",
        textNote: `Deu ruim na api!`,
        imgIcon: "erro",
        imgAlt:
          "Imagem de ilustração de aviso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    }
    //chamar a api
    try {
      const promise = await api.post("/TiposEvento", { titulo: titulo });
      console.log("CADASTRADO COM SUCESSO");
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      console.log(promise.data);
      setTitulo(""); //limpa a variavel

      const promiseGet = await api.get("/TiposEvento");
      setTipoEventos(promiseGet.data);
    } catch (error) {
      console.log("Deu ruim na api");
    }
  }

  //atualizacao dos dados
  async function handleUpdate(e) {
    e.preventDefault();
    
    //propriedade:valor

    try {
      const retorno = await api.put('/TiposEvento/' + idEvento, {titulo: titulo})

      const retornoGet = await api.get('TiposEvento/');
      setTipoEventos(retornoGet.data);

      editActionAbort();
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Problemas na atualizacao. Verifique a conexao com a internet!`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de perigo.",
        showMessage: true,
      });
      
    }
  }


  async function showUpdateForm(idElemento) {
    setFrmEdit(true);
    //fazer um getById para pegar os dados
    
    try {
      const retorno = await api.get('/TiposEvento/' + idElemento);

      setTitulo(retorno.data.titulo);
      setIdEvento(retorno.data.idTipoEvento);
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Deu ruim na api!`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de perigo.",
        showMessage: true,
      });
    }
    
  }

  function editActionAbort() {
    setFrmEdit(false);
    setTitulo("")
    setIdEvento(null);
    
  }

  async function handleDelete(id) {
  
    try {
      const retorno = await api.delete(`/TiposEvento/${id}`);
      console.log("CADASTRADO COM SUCESSO");
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      const promiseGet = await api.get("/TiposEvento");
      setTipoEventos(promiseGet.data);
    } catch (error) {
      console.log("Deu ruim na api");
    }
  }

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {showSpinner ? <Spinner/> : null }
      {/*cadastro de tipo de eventos*/}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Página Tipos de Eventos"} />
            <ImageIllustrator alterText={""} imageRender={eventTypeImage} />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              {!frmEdit ? ( //if
                <>
                  {/*Cadastrar */}
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
                  {/* <span>{titulo}</span> */}
                  <Button
                    type={"submit"}
                    id={"cadastrar"}
                    name={"cadastrar"}
                    textButton={"Cadastrar"}
                  />
                </>
              ) : (
                //else
                <>
                  <Input
                    id="titulo"
                    placeholder="Título"
                    name="titulo"
                    type="text"
                    required="required"
                    value={titulo}
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />
                  <div className="buttons-editbox">
                    <Button
                      textButton="Atualizar"
                      id="atualizar"
                      name="atualizar"
                      type="submit"
                      additionalClass="button-component--middle"
                    />
                    <Button
                      textButton="Cancelar"
                      id="cancelar"
                      name="cancelar"
                      type="button"
                      manipulationFunction={editActionAbort}
                      additionalClass="button-component--middle"
                    />
                  </div>
                </>
              )}
            </form>
          </div>
        </Container>
      </section>

      {/*listagem de tipo de eventos*/}
      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista Tipo de Eventos"} color="white" />
          <TableTp
            dados={tipoEventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default TipoEventosPage;