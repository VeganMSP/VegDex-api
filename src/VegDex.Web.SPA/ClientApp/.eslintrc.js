module.exports = {
  "env": {
    "browser": true,
    "es2021": true,
  },
  "parser": "@typescript-eslint/parser",
  "extends": [
    "eslint:recommended",
    "plugin:react/recommended",
    "plugin:@typescript-eslint/recommended"
  ],
  "parserOptions": {
    "ecmaVersion": 11,
    "sourceType": "module"
  },
  "settings": {
    "react": {
      "version": "detect"
    }
  },
  "plugins": ["react", "react-hooks"],
  "rules": {
    "react/react-in-jsx-scope": "off",
    "react/jsx-filename-extension": [1, { "extensions": [".jsx", ".tsx"] }], //should add ".ts" if typescript project
    "react/display-name": 1,
    "quotes": ["warn", "double"],
    "semi": "warn"
  }
};
