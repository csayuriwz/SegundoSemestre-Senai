import React, { useContext } from "react";
import "./PerfilUsuario.css";
import iconeLogout from "../../assets/images/icone-logout.svg";
import { UserContext } from "../../Context/authContext";
import { Link, useNavigate } from "react-router-dom";

const PerfilUsuario = () => {
  const navigate = useNavigate();
  const { userData, setUserData } = useContext(UserContext);

  const Logout = () => {
    localStorage.clear();
    setUserData({});
    navigate("/");
  };

  return (
    <div className="perfil-usuario">
      {userData.name ? (
        <>
          <span className="perfil-usuario__menuitem">{userData.name}</span>

          <img
          onClick={Logout}
            title="Deslogar"
            className="perfil-usuario__icon"
            src={iconeLogout}
            alt="imagem ilustrativa de uma porta de saída do usuário "
          />
        </>
      ) : (
        <Link to="/login" className="perfil-usuario__menuitem">
          Login
        </Link>
      )}
    </div>
  );
};

export default PerfilUsuario;
