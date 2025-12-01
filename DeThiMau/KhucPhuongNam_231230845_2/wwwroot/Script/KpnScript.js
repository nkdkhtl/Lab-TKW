$(document).ready(function () {
  function loadProducts(maLoai, keyword) {
    $.ajax({
      url: "Home/GetHangByMaLoai",
      type: "GET",
      data: { maLoai: maLoai, keyword: keyword },
      dataType: "json",
      success: function (res) {
        var container = $(".section.group.container");
        container.empty();

        if (!res || res.length === 0) {
          container.append("<div>Không có sản phẩm nào cả</div>");
        } else {
          $.each(res, function (index, hang) {
            var html = `<div class="grid_1_of_4 images_1_of_4">
                          <a href="preview.html"><img src="/Content/images/${hang.anh}" alt="" /></a>
                          <h2>${hang.tenHang}</h2>
                          <div class="price-details">
                            <div class="price-number">
                              <p><span class="rupees">$${hang.gia}</span></p>
                            </div>
                            <div class="add-cart">
                              <h4><a href="preview.html">Add to Cart</a></h4>
                            </div>
                            <div class="clear"></div>
                          </div>
                        </div>`;
            container.append(html);
          });
        }
      },
      error: function (xhr, status, err) {
        console.error("Failed to load products:", err, xhr.responseText);
      },
    });
  }

  function performSearch() {
    var keyword = $(".search_box input[type='text']").val().trim();

    if (keyword === "" || keyword === "Search") {
      return;
    }

    console.log(keyword);
    loadProducts(null, keyword);
  }

  $.ajax({
    url: "Home/GetLoaiHang",
    type: "GET",
    dataType: "json",
    success: function (response) {
      var navbar = $(".menu > ul");
      navbar.append('<li class="active"><a href="#">Khúc Phương Nam</a></li>');
      $.each(response, function (index, loaihang) {
        var item = `<li><a href="#" data-id=${loaihang.maLoai}>${loaihang.tenLoai}</a></li>`;
        navbar.append(item);
      });
      navbar.append(``);
      navbar.append('<div class="clear"></div>');

      loadProducts(null);
    },
    error: function (xhr, status, err) {
      console.error("Failed to load categories:", err);
    },
  });

  // Handle menu clicks
  $(document).on("click", ".menu ul li a", function (e) {
    e.preventDefault();
    $(".menu ul li").removeClass("active");
    $(this).parent().addClass("active");
    var maLoai = $(this).data("id");
    loadProducts(maLoai);
  });

  // Gọi khi click button
  $(document).on("click", ".search_box input[type='button']", function (e) {
    e.preventDefault();
    performSearch();
  });

  $(document).on("keypress", ".search_box input[type='text']", function (e) {
    if (e.which === 13) {
      e.preventDefault();
      performSearch();
    }
  });
});
