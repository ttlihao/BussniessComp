import React, { useState } from "react";
import "./HomePage.scss";
import { IoIosArrowDroprightCircle } from "react-icons/io";
import FlipCard from "@/components/FlipCard/FlipCard";
import TestimonialCarousel from "@/components/TestimonialCarousel/TestimonialCarousel";

function HomePage() {
  return (
    <div className="mt-[82px] home-container">
      <div className="h-banner">
        <div>
          <h1>Tạo ra hương vị của riêng bạn</h1>
          <p>
            Chọn, pha trộn hạt cà phê và bao bì theo phong cách của bạn. Đặt
            ngay hôm nay!
          </p>
          <button>Khám phá ngay</button>
        </div>
      </div>

      <div className="h-shop-info">
        <h1>Vì sao bạn sẽ yêu thích chúng tôi?</h1>
        <div>
          <span>
            <img src="/icons/coffee.png" alt="coffee" />
            <h3>Tự chọn tỉ lệ hạt</h3>
            <p>
              Thỏa sức sáng tạo blend cà phê với những loại hạt rang xay cao cấp
              từ các vùng trồng nổi tiếng như Arabica, Robusta, và nhiều hơn
              nữa.
            </p>
          </span>
          <span>
            <img src="/icons/box.png" alt="box" />
            <h3>Bao Bì Cá Nhân Hoá</h3>
            <p>
              Không chỉ là cà phê, mà còn là câu chuyện của bạn. Chúng tôi cung
              cấp dịch vụ thiết kế bao bì độc quyền, nơi bạn có thể thêm tên,
              thông điệp hoặc hình ảnh yêu thích.
            </p>
          </span>
          <span>
            <img src="/icons/quality.png" alt="quality" />
            <h3>Chất Lượng Thượng Hạng</h3>
            <p>
              Chúng tôi cam kết sử dụng những hạt cà phê chất lượng nhất, được
              chọn lọc từ những nông trại uy tín tại Tây Nguyên. Tất cả các hạt
              cà phê đều được rang xay tại chỗ để đảm bảo độ tươi ngon và giữ
              trọn vẹn hương vị.
            </p>
          </span>
        </div>
      </div>

      <div className="h-title">CÂU CHUYỆN CỦA CHÚNG TÔI</div>

      <div className="h-story-infos">
        <div className="h-story">
          <div>
            <h1>GuYou</h1>
            <h2>Và câu chuyện truyền cảm hứng</h2>
            <p>
              Vào năm 2018, giữa những cánh đồng cà phê bạt ngàn của vùng đất
              Tây Nguyên, một giấc mơ lớn bắt đầu chớm nở. GuYou không chỉ là
              một thương hiệu cà phê, mà là sự kết tinh từ tình yêu và niềm đam
              mê dành cho từng hạt cà phê nguyên chất của người sáng lập. Với
              mong muốn mang đến cho mọi người những tách cà phê thực sự “sạch”
              nguyên bản và đậm đà hương vị của tự nhiên, GuYou ra đời như một
              hành trình kết nối giữa thiên nhiên, con người và niềm tự hào về
              những giá trị truyền thống. Năm 2024, GuYou quyết định làm điều mà
              không nhiều thương hiệu dám làm: Cho phép khách hàng tự “mix” cà
              phê theo tỉ lệ mong muốn, để mỗi tách cà phê mang đậm dấu ấn cá
              nhân. Từ những bước đi nhỏ bé, GuYou không ngừng lớn mạnh. Đó là
              hành trình dài từ tình yêu với cà phê, với đất mẹ Tây Nguyên và
              mong muốn mang đến một trải nghiệm cà phê nguyên chất, thuần khiết
              cho mỗi người.
            </p>
            <span>
              <IoIosArrowDroprightCircle color="#ba0000" />
              Xem thêm
            </span>
          </div>
          <img src="./imgs/story1.png" alt="story1" />
        </div>
        <div className="h-story">
          <img src="./imgs/story2.png" alt="story2" />
          <div>
            <div>
              <h2>Sứ mệnh</h2>
              <p>
                Mang đến những tách cà phê nguyên chất, đậm đà từ thiên nhiên
                nhằm mang lại trải nghiệm tuyệt vời cho khách hàng. Sự kết nối
                giữa nông dân và người tiêu dùng giúp tạo ra giá trị bền vững,
                lâu dài
              </p>
            </div>
            <div>
              <h2>Tầm nhìn</h2>
              <p>
                Hướng đến trở thành thương hiệu cà phê uy tín hàng đầu tại Việt
                Nam, được khách hàng yêu thích vì chất lượng. Chúng tôi mong
                muốn đưa hương vị cà phê Việt Nam ra thế giới và mở rộng thị
                trường quốc tế
              </p>
            </div>
          </div>
        </div>
      </div>

      <div className="h-title h-title-2">LỰU CHỌN Ở BẠN</div>

      <div className="h-intro-coffee">
        <h2>“Mix” Cà phê theo sở thích</h2>
        <p>
          Tính năng mix cà phê theo sở thích cho phép khách hàng tuỳ chỉnh tỉ lệ
          giữa các loại hạt cà phê như robusta, arabica và culi . Khách hàng có
          thể tạo ra tách cà phê hoàn hảo theo đúng khẩu vị cá nhân, từ độ đậm,
          chua đến hương thơm. Sự linh hoạt này mang đến trải nghiệm độc đáo và
          cá nhân hoá, giúp mỗi tách cà phê đều trở thành tác phẩm riêng biệt
        </p>
        <h3>Gợi ý những hương vị yêu thích dành riêng cho bạn</h3>
        <div className="coffee-list-items">
          {/* <div className="coffee-item"> */}
          {[...Array(6)].map((_, index) => (
            <FlipCard key={index} />
          ))}
          {/* </div> */}
        </div>

        <button className="h-btn-try">THỬ NGAY</button>
      </div>

      <div className="h-customer-experience">
        <h3 className="title">Trải Nghiệm Từ Khách Hàng</h3>
        <TestimonialCarousel />
      </div>
    </div>
  );
}

export default HomePage;
