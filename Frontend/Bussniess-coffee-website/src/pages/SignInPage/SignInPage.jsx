import React from "react";
import "./SignInPage.scss";
import { Button, Checkbox, Form, Input } from "antd";

function SignInPage() {
  return (
    <div className="signin-container">
      <div className="signin-wrapper">
        <h1>Đăng nhập</h1>
        {/* <p>
          Bạn chưa có tài khoản? <a href="">Đăng Kí</a>
        </p> */}
        <p class="font-medium text-lg text-center mb-6 text-white">
          Bạn chưa có tài khoản?
          <a href="" class="underline text-white hover:text-[#ba0000]">
            Đăng Kí
          </a>
        </p>

        <div className="btn-login-with">
          <img src="icons/google.png" alt="google icon" />
          <p>Tiếp tục với Google</p>
        </div>
        <div className="btn-login-with">
          <img src="icons/facebook.png" alt="facebook icon" />
          <p>Tiếp tục với Facebook</p>
        </div>
        {/* <div class="flex items-center my-4">
          <div class="flex-1 border-t border-gray-300"></div>
          <span class="px-4 text-gray-500 bg-white">Hoặc</span>
          <div class="flex-1 border-t border-gray-300"></div>
        </div> */}
        <div class="flex items-center my-4">
          <div class="flex-1 border-t border-white"></div>
          <span class="px-4 text-white">Hoặc</span>
          <div class="flex-1 border-t border-white"></div>
        </div>

        <Form name="login" layout="vertical">
          <Form.Item
            // label="Địa chỉ email"
            name="email"
            className="form-custom"
            rules={[{ required: true, message: "Vui lòng nhập email!" }]}
          >
            <label className="form-label">Địa chỉ email</label>
            <Input placeholder="Enter your Email" className="form-input" />
          </Form.Item>

          <Form.Item
            // label="Mật khẩu của bạn"
            name="password"
            className="form-custom"
            rules={[{ required: true, message: "Vui lòng nhập mật khẩu!" }]}
          >
            <label className="form-label">Mật khẩu của bạn</label>
            <Input.Password
              placeholder="Enter your Password"
              className="form-input"
            />
          </Form.Item>

          {/* <a href="">Quên mật khẩu?</a>
          <div className="check-login">
            <Checkbox />
            <p>Giữ tôi đăng nhập đến khi tôi đăng xuất</p>
          </div> */}
          <div class="text-white">
            <a
              href=""
              class="block text-right underline hover:text-[#ba0000] mt-[-18px]"
            >
              Quên mật khẩu
            </a>
            <div class="flex items-center mt-0 mb-4">
              <input type="checkbox" class="w-4 h-4 mr-2" />
              <p>Giữ tôi đăng nhập đến khi tôi đăng xuất</p>
            </div>
          </div>

          {/* <Form.Item>
            <Button
              type="primary"
              htmlType="submit"
              block
              className="btn-submit-custom"
            >
              Đăng nhập
            </Button>
          </Form.Item> */}
          <Form.Item>
            <button type="submit" className="btn-custom">
              Đăng nhập
            </button>
          </Form.Item>
        </Form>
      </div>
    </div>
  );
}

export default SignInPage;
