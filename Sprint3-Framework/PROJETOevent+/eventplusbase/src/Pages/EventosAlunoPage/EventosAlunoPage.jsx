import React, { useContext, useEffect, useState } from "react";
import Header from "../../Components/Header/Header";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import Table from "../EventosAlunoPage/TableEva/TableEva";
import Container from "../../Components/Container/Container";
import { Select } from "../../Components/FormComponents/FormComponents";
import Spinner from "../../Components/Spinner/Spinner";
import Modal from "../../Components/Modal/Modal";
import api from "../../Services/Service";

import "./EventosAlunoPage.css";
import { UserContext } from "../../Context/authContext";

const EventosAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: "1", text: "Todos os eventos" },
    { value: "2", text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);
  const [notifyUser, setNotifyUser] = useState({});
  const [toggle, setToggle] = useState(false);

  // recupera os dados globais do usuário
  const {   userData, setUserData } = useContext(UserContext);

  useEffect(() => {
    
    loadEventsType();

    setShowSpinner(false);
  }, [tipoEvento, userData.userId]);


  async function loadEventsType() {
    setShowSpinner(true);

    //trazer todos os eventos
    try {
      if (tipoEvento === "1") {
        const retorno = await api.get("/Evento");
        const retornoM = await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`);

        const dadosMarcados = verificaPresenca(retorno.data,retornoM.data);
        // // console.log("bla bla bla");
        console.log(dadosMarcados);
        console.log(retorno.data);
        
        setEventos(retorno.data);          
      } else {
        let arrEventos = [];
        const retornoM = await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`);
        console.log(retornoM);
        retornoM.data.forEach((e) => {
          arrEventos.push({
            ...e.evento,
            situacao : e.situacao,
            idPresencaEvento: e.idPresencaEvento
            });
        });
        console.log(arrEventos);
        console.log(retornoM.data);
        setEventos(arrEventos);
      }
    } catch (error) {
      setNotifyUser({
        titleNote: "Atenção",
        textNote: `Deu ruim na API`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    }
        setShowSpinner(false);

  }



  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  async function loadMyComentary(idComentary) {
    return "????";
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const postMyComentary = () => {
    alert("Remover o comentário");
  };


  const commentaryRemove = () => {
    alert("Remover o comentário");
  };

  const verificaPresenca = (arrAllEvents, eventsUser) => {
    for (let x = 0; x < arrAllEvents.length; x++) {

      for (let i = 0; i < eventsUser.length; i++) {

        if (arrAllEvents[x].idEvento === eventsUser[i].idEvento) {

          arrAllEvents[x].situacao = true;
          arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento;

          break;
        }
      }
    }
  };

  // async function getState()
  // {
  //   try {
  //     const retornoGet = await api.get("/Evento");
  //     const retorno = await api.get(`/PresencasEvento/ListarMinhas/${userData.userId}`);
  //     setEventos(retornoGet.data)
  //   } catch (error) {
  //     alert("Algo deu Errado")
  //   }
  // }

 async function handleConnect(idEvent, whatTheFunction, idPresencaEvento = null) {
    // {
    //   "situacao": true,
    //   "idUsuario": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    //   "idEvento": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    // }
    if (whatTheFunction === "connect") {
      try {
        const retorno = await api.post(`/PresencasEvento`,
        {
          situacao: true,
          idUsuario: userData.userId,
          idEvento: idEvent
        }
        )
        
        loadEventsType();
      } catch (error) {
        console.log("Erro ao conectar");
        console.log(error);
      }
      return;
    }

    //unconnect
    try {
      const retorno = await api.delete(`/PresencasEvento/${idPresencaEvento}`
      )
      console.log(retorno);
      loadEventsType();
    } catch (error) {
      console.log("Erro ao conectar");
      console.log(error);
    }
      // alert("Desconectar do evento" + idEvent);
  }
  return (
    <>
      {/* <Header exibeNavbar={exibeNavbar} setExibeNavbar={setExibeNavbar} /> */}

      <MainContent>
        <Container>
          <Title titleText={"Eventos"} additionalClass="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            dados={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultValue={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnDelete={commentaryRemove}
          fnGet={loadMyComentary}
          fnPost={postMyComentary}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
