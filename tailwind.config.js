/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./Pages/**/*.{html,cshtml,razor}', './Shared/**/*.{html,cshtml,razor}', './node_modules/flowbite/**/*.js'],
  theme: {
    extend: {},
  },
  plugins: [require('flowbite/plugin')({ charts: false })],
}

