$(document).ready(function () {
  $(".category_link").click(function (e) {
    e.preventDefault();
    var maLoai = $(this).data("maloai");
    $(".category_link").parent().removeClass('active');
      $(this).parent().addClass('active');
    $.ajax({
      url: "Home/GetLoaiHangByMaHang",
      type: "GET",
      data: { maLoai: maLoai },
      dataType: "json",
      success: function (data) {
        $("#product-container").empty();

        if (data.length <= 0) {
          $("#product-container").html("<p>Không có sản phẩm nào cả.</p>");
          return;
        }

        $.each(data, function (index, hang) {
          var html = `
                        <div class="grid_1_of_4 images_1_of_4">
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
					</div>
                    `;

          $("#product-container").append(html);
        });
      },
      error: function () {
        alert("Có lỗi xảy ra khi tải dữ liệu(GET)");
      },
    });
  });
});
