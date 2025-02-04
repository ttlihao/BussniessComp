import React, { useState } from "react";
import "./FlipCard.scss";

function FlipCard() {
  const [flipped, setFlipped] = useState(false);

  return (
    <div
      className="flip-card"
      onMouseEnter={() => setFlipped(true)}
      onMouseLeave={() => setFlipped(false)}
    >
      <div className={`flip-card-inner ${flipped ? "flipped" : ""}`}>
        {/* Front Side */}
        <div className="flip-card-front">
          <div className="img-coffee">
            <img
              className="deco-img"
              src="/icons/decorations/deco1.png"
              alt="deco1"
            />
            <img
              className="deco-img"
              src="/icons/decorations/deco2.png"
              alt="deco2"
            />
            <img
              className="deco-img"
              src="/icons/decorations/deco3.png"
              alt="deco3"
            />
            <img
              className="deco-img"
              src="/icons/decorations/deco4.png"
              alt="deco4"
            />
            <img
              className="deco-img"
              src="/icons/decorations/deco5.png"
              alt="deco5"
            />
            <img
              className="deco-img"
              src="/icons/decorations/deco6.png"
              alt="deco6"
            />
            <img
              src="https://s3-alpha-sig.figma.com/img/6f5b/8cee/499defeee493dd67c2344236b1b0fb2c?Expires=1739750400&Key-Pair-Id=APKAQ4GOSFWCW27IBOMQ&Signature=hjSRfgFc4GDUBlAV8VFzSsc6RK2asuRtonqKPMd~vCSxO8yyLyRBFRj~4URy4UcRdtdMSTSKAEyOEut7wD2zqoXn-IZxncgJatlNM3L2f89V2vwTPBD73zoMTNfAj2yxEUoyomhjQ7x4vvrqDdYcqBjSCvAv6a5yBqNiY6-X2Py4-szj8N9aioFe3ixvWSB-s1~kJ4TincFXqKHp~SbZVsMFYgr696L6pCEjc2s7wbQsfS-~hXh0IaOehgWML1Q0Db1aJw4YOJIQSn5SujkEXXlP-tPRxyhZtfPxlFMIHhumVDNHCDg2lBS3J2lwjmldemLt-73mLCD6DiUV8yyI9A__"
              alt="coffee img"
              className="coffee-img"
            />
          </div>
          <h3>Hương vị nhẹ nhàng</h3>
          <span>
            <p>70% Arabica</p>
            <p>30% Robusta</p>
            {/* <p>30% Robusta</p> */}
          </span>
        </div>
        {/* Back Side */}
        <div className="flip-card-back">
          <span>
            <p>
              Đậm đà, mạnh mẽ và tràn đầy năng lượng với hương vị chocolate đen
              và chút đắng đặc trưng. Sự hoà trộn này mang đậm phong cách cà phê
              truyền thống Việt Nam, hoàn hảo để bắt đầu một ngày làm việc hiệu
              quả.
            </p>
          </span>

          <h2>Hương vị nhẹ nhàng</h2>

          <button>Thử ngay</button>
        </div>
      </div>
    </div>
  );
}

export default FlipCard;
