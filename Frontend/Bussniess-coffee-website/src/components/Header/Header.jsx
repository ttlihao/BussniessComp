import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Cookies from "js-cookie";
import { FaRegUserCircle } from "react-icons/fa";
import { FaCartShopping } from "react-icons/fa6";
import "./Header.scss";

function Header() {
  const navigate = useNavigate();
  const [userData, setUserData] = useState(null);
  const user = Cookies.get("userData");

  // Kiểm tra cookie khi component mount
  useEffect(() => {
    if (user) {
      setUserData(JSON.parse(user)); // Chuyển JSON string thành object
    } else {
      setUserData(null);
    }
  }, [user]);

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

      {/* Kiểm tra nếu có userData trong cookie */}
      {userData ? (
        <div className="header-item header-user-item">
          <FaRegUserCircle
            size={39}
            color="white"
            style={{ cursor: "pointer" }}
          />
          <button>
            Giỏ hàng
            <FaCartShopping size={25} color="white" />
          </button>
        </div>
      ) : (
        <div className="header-item">
          <button className="h-btn btn-sign-in" onClick={handleSignIn}>
            Đăng nhập
          </button>
          <button className="h-btn btn-sign-up" onClick={handleSignUp}>
            Đăng kí
          </button>
        </div>
      )}
    </div>
  );
}

export default Header;
