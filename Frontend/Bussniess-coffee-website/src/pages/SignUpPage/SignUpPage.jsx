import React from "react";
import "./SignUpPage.scss";
import { Form, Input } from "antd";

function SignUpPage() {
  return (
    <div className="signup-container">
      {/* <div > */}

      <Form name="register" layout="vertical" className="signup-wrapper">
        <h1>Tạo tài khoản</h1>
        <Form.Item
          name="name"
          className="form-custom"
          hasFeedback
          // validateTrigger="onBlur"
          validateFirst
          rules={[{ min: 0, message: "Vui lòng nhập tên!" }]}
        >
          <Input placeholder="Tên" className="form-input" />
        </Form.Item>

        <Form.Item
          name="usernam"
          className="form-custom"
          hasFeedback
          rules={[{ required: true, message: "Vui lòng nhập username!" }]}
        >
          <label className="form-label">Tên Đăng nhập</label>
          <Input placeholder="Enter your Username" className="form-input" />
        </Form.Item>

        <Form.Item
          name="email"
          className="form-custom"
          hasFeedback
          rules={[{ required: true, message: "Vui lòng nhập email!" }]}
        >
          <label className="form-label">Email</label>
          <Input placeholder="Enter your Email" className="form-input" />
        </Form.Item>

        <div className="flex gap-[22px]">
          <Form.Item
            name="password"
            className="form-custom"
            hasFeedback
            rules={[{ required: true, message: "Vui lòng nhập mật khẩu!" }]}
          >
            <label className="form-label">Mật khẩu</label>
            <Input.Password
              placeholder="Enter your Password"
              className="form-input"
            />
          </Form.Item>

          <Form.Item
            name="confirm"
            className="form-custom"
            hasFeedback
            rules={[{ required: true, message: "Vui lòng nhập mật khẩu!" }]}
          >
            <label className="form-label">Xác nhận Mật khẩu</label>
            <Input.Password
              placeholder="Enter your Password again"
              className="form-input"
            />
          </Form.Item>
        </div>

        <Form.Item className="flex justify-center items-center">
          <button type="submit" className="btn-custom-register">
            Đăng nhập
          </button>
        </Form.Item>

        <p>
          Bằng việc đăng ký, bạn đồng ý với <u>Điều Khoản Dịch Vụ</u> và{" "}
          <u>Chính Sách Bảo Mật</u> bao gồm việc sử dụng <u>Cookie</u>
        </p>
      </Form>
      {/* </div> */}
    </div>
  );
}

export default SignUpPage;
