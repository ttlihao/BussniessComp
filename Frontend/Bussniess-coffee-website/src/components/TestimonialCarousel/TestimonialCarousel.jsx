// import { useState } from "react";
// import { FaChevronLeft, FaChevronRight } from "react-icons/fa";
// import { Rate } from "antd";

// const testimonials = [
//   {
//     avatar:
//       "https://play-lh.googleusercontent.com/Dj7cruHjT5ejOFrF5HcW2Ryo-n79imSBbUf2OVfrZkUII1httatA30zl5-x8JSBdLzG-",
//     name: "John Doe",
//     comment: "Sản phẩm rất tuyệt vời! Tôi rất hài lòng.",
//     rating: 5,
//   },
//   {
//     avatar:
//       "https://cdn2.fptshop.com.vn/unsafe/800x0/avatar_anime_nam_cute_14_60037b48e5.jpg",
//     name: "Jane Smith",
//     comment: "Dịch vụ tốt, giao hàng nhanh chóng.",
//     rating: 4.5,
//   },
//   {
//     avatar:
//       "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQlrDBSmMQyqmbeYR0Xbhkf0f8YmLQGju_8nw&s",
//     name: "Michael Brown",
//     comment: "Chất lượng sản phẩm đáng kinh ngạc!",
//     rating: 5,
//   },
//   {
//     avatar:
//       "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzXYJjodFz_K34O-knK2K_A80iwv4007bb3Q&s",
//     name: "Emily White",
//     comment: "Sẽ giới thiệu cho bạn bè!",
//     rating: 4.5,
//   },
//   {
//     avatar:
//       "https://i.pinimg.com/originals/08/d2/f3/08d2f33ea27807f1ba381f5aa335ae63.jpg",
//     name: "David Wilson",
//     comment: "Dịch vụ chăm sóc khách hàng tốt!",
//     rating: 5,
//   },
// ];

// export default function TestimonialCarousel() {
//   const [index, setIndex] = useState(0);

//   const nextSlide = () => {
//     setIndex((prev) => (prev + 1) % testimonials.length); // Đảm bảo quay vòng
//   };

//   const prevSlide = () => {
//     setIndex((prev) => (prev - 1 + testimonials.length) % testimonials.length); // Đảm bảo quay vòng
//   };

//   // Tính toán số lượng phần tử cần hiển thị
//   const remainingItems = testimonials.slice(index, index + 3);
//   const displayTestimonials =
//     remainingItems.length < 3
//       ? [...remainingItems, ...testimonials.slice(0, 3 - remainingItems.length)] // concat nếu ít hơn 3
//       : remainingItems;

//   return (
//     <div className="w-full max-w-md mx-auto p-4 text-center">
//       {/* Hàng 1: Avatar + Nút chuyển */}
//       <div className="flex items-center justify-between relative">
//         <button onClick={prevSlide} className="text-gray-500 hover:text-black">
//           <FaChevronLeft size={24} />
//         </button>
//         <div className="flex space-x-4 items-center">
//           {/* Hiển thị đúng 3 avatar */}
//           {displayTestimonials.map((item, i) => (
//             <img
//               key={i}
//               src={item.avatar}
//               alt={item.name}
//               className={`rounded-full transition-all ${
//                 i === 1 ? "w-[155px] h-[155px]" : "w-[122px] h-[122px]"
//               }`}
//             />
//           ))}
//         </div>
//         <button onClick={nextSlide} className="text-gray-500 hover:text-black">
//           <FaChevronRight size={24} />
//         </button>
//       </div>

//       {/* Hàng 2: Thông tin đi kèm avatar */}
//       <div className="mt-4">
//         <h3 className="text-lg font-bold">{testimonials[index].name}</h3>
//         <p className="text-gray-600 italic">"{testimonials[index].comment}"</p>
//         <Rate
//           value={testimonials[index].rating} // Sử dụng giá trị rating
//           disabled // Chế độ chỉ đọc
//           allowHalf // Cho phép rating lẻ
//           className="text-yellow-500"
//         />
//       </div>
//     </div>
//   );
// }

import { useState } from "react";
import { FaChevronLeft, FaChevronRight } from "react-icons/fa";
import { BiSolidLeftArrow, BiSolidRightArrow } from "react-icons/bi";
import { Rate } from "antd";
import "./TestimonialCarousel.scss"; // Import file SCSS bình thường

const testimonials = [
  {
    avatar:
      "https://play-lh.googleusercontent.com/Dj7cruHjT5ejOFrF5HcW2Ryo-n79imSBbUf2OVfrZkUII1httatA30zl5-x8JSBdLzG-",
    name: "John Doe",
    comment: "Sản phẩm rất tuyệt vời! Tôi rất hài lòng.",
    rating: 5,
  },
  {
    avatar:
      "https://cdn2.fptshop.com.vn/unsafe/800x0/avatar_anime_nam_cute_14_60037b48e5.jpg",
    name: "Jane Smith",
    comment: "Dịch vụ tốt, giao hàng nhanh chóng.",
    rating: 4.5,
  },
  {
    avatar:
      "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQlrDBSmMQyqmbeYR0Xbhkf0f8YmLQGju_8nw&s",
    name: "Michael Brown",
    comment: "Chất lượng sản phẩm đáng kinh ngạc!",
    rating: 5,
  },
  {
    avatar:
      "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzXYJjodFz_K34O-knK2K_A80iwv4007bb3Q&s",
    name: "Emily White",
    comment: "Sẽ giới thiệu cho bạn bè!",
    rating: 4.5,
  },
  {
    avatar:
      "https://p16-va.lemon8cdn.com/tos-alisg-v-a3e477-sg/o4s96kgvfEEVWqBCAB2yYXCRdiBQieAEyrAI25~tplv-tej9nj120t-origin.webp",
    name: "David Wilson",
    comment: "Dịch vụ chăm sóc khách hàng tốt!",
    rating: 5,
  },
];

export default function TestimonialCarousel() {
  const [index, setIndex] = useState(0);

  const nextSlide = () => {
    setIndex((prev) => (prev + 1) % testimonials.length);
  };

  const prevSlide = () => {
    setIndex((prev) => (prev - 1 + testimonials.length) % testimonials.length);
  };

  const remainingItems = testimonials.slice(index, index + 3);
  const displayTestimonials =
    remainingItems.length < 3
      ? [...remainingItems, ...testimonials.slice(0, 3 - remainingItems.length)]
      : remainingItems;

  return (
    <div className="carousel-container">
      <div className="carousel-header">
        <button onClick={prevSlide} className="carousel-button">
          <BiSolidLeftArrow size={28} color="white" />
        </button>
        <div className="carousel-avatar-container">
          {displayTestimonials.map((item, i) => (
            <img
              key={i}
              src={item.avatar}
              alt={item.name}
              className={`carousel-avatar ${i === 1 ? "highlight" : "normal"}`}
            />
          ))}
        </div>
        <button onClick={nextSlide} className="carousel-button">
          <BiSolidRightArrow size={28} color="white" />
        </button>
      </div>

      <div className="carousel-info">
        <h3 className="carousel-name">{testimonials[index].name}</h3>
        <p className="carousel-comment">"{testimonials[index].comment}"</p>
        <Rate
          value={testimonials[index].rating}
          disabled
          allowHalf
          className="carousel-rating"
        />
      </div>
    </div>
  );
}
