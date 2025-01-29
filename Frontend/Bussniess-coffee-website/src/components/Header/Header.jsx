import React from "react";
import "./Header.scss";
import { useNavigate } from "react-router-dom";

function Header() {
  const navigate = useNavigate();

  const handleHome = () => navigate("/");
  const handleSignIn = () => navigate("/sign-in");
  const handleSignUp = () => navigate("/sign-up");
  return (
    <div className="header-container">
      <div
        className="header-item"
        style={{ fontWeight: 700, color: "white", fontSize: 18 }}
      >
        <img
          src="/logo.png"
          alt="logo"
          className="logo-style"
          onClick={handleHome}
        />
      </div>
      <div className="header-item">
        <span className="h-item">Trang chủ</span>
        <span className="h-item">Mix Cà Phê</span>
        <span className="h-item">Sản phẩm</span>
        <span className="h-item">Hành trình</span>
        <span className="h-item">Liên Hệ</span>
      </div>
      <div className="header-item">
        <button className="h-btn btn-sign-in" onClick={handleSignIn}>
          Đăng nhập
        </button>
        <button className="h-btn btn-sign-up" onClick={handleSignUp}>
          Đăng kí
        </button>
      </div>
    </div>
  );
}

export default Header;
