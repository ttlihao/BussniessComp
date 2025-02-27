import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Cookies from "js-cookie";
import { FaRegUserCircle } from "react-icons/fa";
import { FaCartShopping } from "react-icons/fa6";
import { MdOutlineSpaceDashboard, MdLogout } from "react-icons/md";
import { BiPurchaseTagAlt } from "react-icons/bi";
import { IoSettingsOutline } from "react-icons/io5";
import "./Header.scss";

function Header() {
  const navigate = useNavigate();
  const [userData, setUserData] = useState(null);
  const [showDropdown, setShowDropdown] = useState(false);
  const user = Cookies.get("userData");

  useEffect(() => {
    setUserData(user ? JSON.parse(user) : null);
  }, [user]);

  const handleNavigate = (path) => {
    navigate(path);
    setShowDropdown(false);
  };

  const handleLogout = () => {
    Cookies.remove("userData");
    setUserData(null);
    window.location.reload();
  };

  const renderDropdown = () => {
    if (!userData) return null;

    return (
      <div className="dropdownMenu">
        <div className="ddm-item">
          <img
            className="avatar-img"
            src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzXYJjodFz_K34O-knK2K_A80iwv4007bb3Q&s"
            alt="avatar"
          />
          <p>{userData.username}</p>
        </div>

        {userData.roleName === "admin" && (
          <div
            className="ddm-item"
            onClick={() => handleNavigate("/admin/dashboard")}
          >
            <MdOutlineSpaceDashboard size={26} style={{ margin: "0 12px" }} />
            <p>Dashboard</p>
          </div>
        )}

        <div className="ddm-item" onClick={() => handleNavigate("/my-orders")}>
          <BiPurchaseTagAlt size={26} style={{ margin: "0 12px" }} />
          <p>Đơn mua của tôi</p>
        </div>

        <div className="ddm-item" onClick={() => handleNavigate("/settings")}>
          <IoSettingsOutline size={26} style={{ margin: "0 12px" }} />
          <p>Cài đặt</p>
        </div>

        <div className="ddm-item" onClick={handleLogout}>
          <MdLogout size={26} style={{ margin: "0 12px" }} />
          <p>Đăng xuất</p>
        </div>
      </div>
    );
  };

  return (
    <div className="header-container">
      <div className="header-item" onClick={() => handleNavigate("/")}>
        <img src="/logo.png" alt="logo" className="logo-style" />
      </div>

      <div className="header-item">
        <span className="h-item">Trang chủ</span>
        <span className="h-item">Mix Cà Phê</span>
        <span className="h-item" onClick={() => handleNavigate("/products")}>
          Sản phẩm
        </span>
        <span className="h-item">Hành trình</span>
        <span className="h-item">Liên Hệ</span>
      </div>

      {userData ? (
        <div className="header-item header-user-item">
          <div
            className="user-icon"
            onMouseEnter={() => setShowDropdown(true)}
            onMouseLeave={() => setShowDropdown(false)}
          >
            <FaRegUserCircle
              size={39}
              color="white"
              style={{
                cursor: "pointer",
                position: "relative",
              }}
            />
            {showDropdown && renderDropdown()}
          </div>
          <button onClick={() => handleNavigate("/cart")}>
            Giỏ hàng
            <FaCartShopping size={25} color="white" />
          </button>
        </div>
      ) : (
        <div className="header-item">
          <button
            className="h-btn btn-sign-in"
            onClick={() => handleNavigate("/sign-in")}
          >
            Đăng nhập
          </button>
          <button
            className="h-btn btn-sign-up"
            onClick={() => handleNavigate("/sign-up")}
          >
            Đăng kí
          </button>
        </div>
      )}
    </div>
  );
}

export default Header;
