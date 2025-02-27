import React, { useCallback } from "react";
import "./SignUpPage.scss";
import { Form, Input, message } from "antd";
import axios from "axios";
import { useNavigate } from "react-router-dom";

function SignUpPage() {
  const navigate = useNavigate();

  const handleFinish = useCallback(
    async (values) => {
      try {
        const payload = {
          email: values.email,
          username: values.username,
          password: values.password,
          fullName: values.name,
          phoneNumber: values.phone,
          roleID: "0471596f-3055-49d6-8c39-fb4cbb2e600c", // Role mặc định
        };

        const response = await axios.post(
          "https://localhost:7240/api/authenticate/register",
          payload,
          {
            headers: {
              "Content-Type": "application/json",
              Accept: "text/plain",
            },
          }
        );

        if (response.status === 200) {
          message.success("Đăng ký thành công!");
          setTimeout(() => {
            navigate("/sign-in");
          }, 2000); // Chuyển trang sau 2 giây
        }
      } catch (error) {
        console.error("Lỗi đăng ký:", error);
        message.error("Đăng ký thất bại. Vui lòng thử lại!");
      }
    },
    [navigate]
  );

  const handleFinishFailed = useCallback((error) => {
    console.log("Lỗi form:", error);
  }, []);

  return (
    <div className="signup-container mt-[82px]">
      <Form
        name="register"
        layout="vertical"
        className="signup-wrapper"
        onFinish={handleFinish}
        onFinishFailed={handleFinishFailed}
      >
        <h1>Tạo tài khoản</h1>

        {/* Tên */}
        <Form.Item
          name="name"
          className="form-custom"
          hasFeedback
          rules={[{ required: true, message: "Vui lòng nhập tên!" }]}
        >
          <Input placeholder="Tên" className="form-input" autoComplete="name" />
        </Form.Item>

        {/* Số điện thoại */}
        <Form.Item
          name="phone"
          className="form-custom"
          hasFeedback
          normalize={(value) => value.replace(/\s/g, "")}
          rules={[
            { required: true, message: "Vui lòng nhập SĐT!" },
            {
              pattern: /^\d{10}$/,
              message: "Số điện thoại phải có 10 chữ số!",
            },
          ]}
        >
          <Input
            placeholder="Số điện thoại"
            className="form-input"
            autoComplete="tel"
          />
        </Form.Item>

        {/* Tên đăng nhập */}
        <Form.Item
          name="username"
          className="form-custom"
          hasFeedback
          rules={[
            { required: true, message: "Vui lòng nhập username!" },
            { min: 6, message: "Tên đăng nhập phải có ít nhất 6 ký tự!" },
          ]}
        >
          <div>
            <label className="form-label">Tên Đăng nhập</label>
            <Input
              placeholder="Nhập username"
              className="form-input"
              autoComplete="username"
            />
          </div>
        </Form.Item>

        {/* Email */}
        <Form.Item
          name="email"
          className="form-custom"
          hasFeedback
          rules={[
            { required: true, message: "Vui lòng nhập email!" },
            { type: "email", message: "Email không hợp lệ!" },
          ]}
        >
          <div>
            <label className="form-label">Email</label>
            <Input
              placeholder="Nhập email"
              className="form-input"
              autoComplete="email"
            />
          </div>
        </Form.Item>

        {/* Mật khẩu */}
        <div className="flex gap-[22px]">
          <Form.Item
            name="password"
            className="form-custom"
            hasFeedback
            rules={[
              { required: true, message: "Vui lòng nhập mật khẩu!" },
              { min: 8, message: "Mật khẩu phải có ít nhất 8 ký tự!" },
              { max: 20, message: "Mật khẩu không được vượt quá 20 ký tự!" },
              {
                pattern: /[A-Z]/,
                message: "Mật khẩu phải chứa ít nhất 1 chữ in hoa!",
              },
              {
                pattern: /[a-z]/,
                message: "Mật khẩu phải chứa ít nhất 1 chữ thường!",
              },
              {
                pattern: /\d/,
                message: "Mật khẩu phải chứa ít nhất 1 chữ số!",
              },
              {
                pattern: /[\W_]/,
                message: "Mật khẩu phải chứa ít nhất 1 ký tự đặc biệt!",
              },
            ]}
          >
            <div>
              <label className="form-label">Mật khẩu</label>
              <Input.Password
                placeholder="Nhập mật khẩu"
                className="form-input"
                autoComplete="new-password"
              />
            </div>
          </Form.Item>

          {/* Xác nhận mật khẩu */}
          <Form.Item
            name="confirm"
            className="form-custom"
            dependencies={["password"]}
            hasFeedback
            rules={[
              { required: true, message: "Vui lòng nhập lại mật khẩu!" },
              ({ getFieldValue }) => ({
                validator(_, value) {
                  if (!value || getFieldValue("password") === value) {
                    return Promise.resolve();
                  }
                  return Promise.reject(
                    new Error("Mật khẩu xác nhận không khớp!")
                  );
                },
              }),
            ]}
          >
            <div>
              <label className="form-label">Xác nhận Mật khẩu</label>
              <Input.Password
                placeholder="Nhập lại mật khẩu"
                className="form-input"
                autoComplete="new-password"
              />
            </div>
          </Form.Item>
        </div>

        <Form.Item className="flex justify-center items-center">
          <button type="submit" className="btn-custom-register">
            Đăng ký
          </button>
        </Form.Item>

        <p>
          Bằng việc đăng ký, bạn đồng ý với <u>Điều Khoản Dịch Vụ</u> và{" "}
          <u>Chính Sách Bảo Mật</u> bao gồm việc sử dụng <u>Cookie</u>
        </p>
      </Form>
    </div>
  );
}

export default SignUpPage;
