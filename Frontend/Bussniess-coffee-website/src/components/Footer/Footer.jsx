import React from "react";
import "./Footer.scss";
import { IoMdHome } from "react-icons/io";
import { FaPhoneAlt } from "react-icons/fa";
import { IoMdMail } from "react-icons/io";
import { FaFacebookSquare } from "react-icons/fa";

function Footer() {
  return (
    <footer className="footer-container">
      <div className="footer-wrapper">
        <div className="footer-item">
          <h2>LOGO</h2>
          <p>
            Xưởng cung cấp cà phê sạch tốt cho sức khoẻ. Chúng tôi tự hào cung
            cấp hạt cà phê chất lượng cao, được chọn lọc từ các vùng trồng cà
            phê nổi tiếng. Hương vị cà phê của riêng bạn, đậm đà từ tâm !
          </p>
        </div>
        <div className="footer-item">
          <h2>Công ty</h2>
          <ul>
            <li>
              <a href="">Hành trình</a>
            </li>
            <li>
              <a href="">Mix Cà Phê</a>
            </li>
            <li>
              <a href="">Sản Phẩm</a>
            </li>
            <li>
              <a href="">Liên hệ</a>
            </li>
          </ul>
        </div>
        <div className="footer-item">
          <h2>Liên hệ</h2>
          <span>
            <IoMdHome size={20} />
            <p>113/4/40 Võ Duy Ninh, P22 Bình Thạnh</p>
          </span>
          <span>
            <FaPhoneAlt size={20} />
            <p>Hotline : 123 45678910</p>
          </span>
          <span>
            <IoMdMail size={20} />
            <p>GuYou@gmail.com</p>
          </span>
        </div>
        <div className="footer-item">
          <h2>Theo dõi tại</h2>
          <div>
            <FaFacebookSquare size={20} />
          </div>
        </div>
      </div>
      <span className="footer">
        Copyright &copy; GuYou | All Rights Reserved
      </span>
    </footer>
  );
}

export default Footer;
