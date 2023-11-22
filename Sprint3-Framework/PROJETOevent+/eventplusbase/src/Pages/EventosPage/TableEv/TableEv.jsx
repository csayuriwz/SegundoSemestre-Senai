import React from "react";
import "./TableEv.css";

import editPen from "../../../assets/images/edit-pen.svg";
import trashDelete from "../../../assets/images/trash-delete.svg";

const TableEv = ({ dados, fnUpdate, fnDelete }) => {
  return (
    <table className="table-data">
      <thead className="table-data__head">
        <tr className="table-data__head-row">
          <th className="table-data__head-title table-data__head-title--big">
            Evento
          </th>



          <th className="table-data__head-title table-data__head-title--big">
            Descricao
          </th>



          <th className="table-data__head-title table-data__head-title--big">
            Tipo Evento
          </th>



          <th className="table-data__head-title table-data__head-title--big">
            Data do Evento
          </th>



          <th className="table-data__head-title table-data__head-title--little">
            Editar
          </th>



          <th className="table-data__head-title table-data__head-title--little">
            Deletar
          </th>
        </tr>
      </thead>

      <tbody>
        {dados.map((Evento) => {
          return (
            <tr className="table-data__head-row">
              <td className="table-data__data table-data__data--big">
                {Evento.nomeEvento}
              </td>


              <td className="table-data__data table-data__data--big">
                {Evento.descricao}
              </td>


              <td className="table-data__data table-data__data--big">
                {Evento.tiposEvento.titulo}
              </td>



              <td className="table-data__data table-data__data--big">
                {new Date(Evento.dataEvento).toLocaleDateString()}
              </td>




              <td className="table-data__data table-data__data--little">
                <img
                  className="table-data__icon"
                  src={editPen}
                  alt=""
                  onClick={() => {
                    fnUpdate(Evento.idEvento);
                  }}
                />
              </td>

              <td className="table-data__data table-data__data--little">
                <img
                  className="table-data__icon"
                  src={trashDelete}
                  alt=""
                  onClick={() => {
                    fnDelete(Evento.idEvento);
                  }}
                />
              </td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
};

export default TableEv;
